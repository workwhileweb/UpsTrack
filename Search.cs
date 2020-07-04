using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTT.Extension;
using TTT.Net;
using unvell.ReoGrid;
using unvell.ReoGrid.IO;

namespace UpsTrack
{
    public partial class Search : Form
    {
        private readonly string _excelFile = Application.StartupPath + "\\data.xlsx";

        public Search()
        {
            InitializeComponent();
            //Client.Instance.ProxyFiddlerSet();
            //Client.Instance.Request("https://www.ups.com/track?loc=en_US&tracknum=undefined&requester=ST/");
            reoGridControl.CurrentWorksheet.EnableSettings(WorksheetSettings.Edit_AutoExpandColumnWidth);
            //reoGridControl.CurrentWorksheet.SetRangeStyles();
        }

        public IEnumerable<string> SearchTracks(string zip, string fromDate, string toDate, string refer = "11")
        {
            zip = zip.Trim();
            if (zip.Length < 5) zip = ("00000" + zip).Substring(zip.Length - 5);
            else if (zip.Length > 5) zip = zip.Substring(0, 5);
            var post =
                $"{{\"locale\":\"en_US\",\"shipmentType\":\"Package\",\"shipmentReference\":\"{refer}\",\"shipperAccount\":\"\",\"dateRangeFrom\":\"{fromDate}\",\"dateRangeTo\":\"{toDate}\",\"destinationCountry\":\"us\",\"destinationPostalCode\":\"{zip}\"}}";
            Client.Instance.Accept = "application/json, text/plain, */*";
            Client.Instance.ContentType = "application/json";
            var json = Client.Instance.Request("https://www.ups.com/track/api/Track/GetTrackByReference?loc=en_US",
                post);
            return json.BetweenAll("\"trackingNumber\":\"", "\"");
        }

        public string GetJsonValue(string json, string name)
        {
            return json.Between(name.Quote() + ":\"", "\"");
        }

        public UpsTrackItem GetTrackDetail(string zip, string refer, params string[] track)
        {
            const string url = "https://www.ups.com/track/api/Track/GetStatus?loc=en_US";
            var tracks = string.Join(",", track.Select(s => s.Quote()));
            var post = $"{{\"Locale\":\"en_US\",\"TrackingNumber\":[{tracks}]}}";
            var json = Client.Instance.Request(url, post);
            return new UpsTrackItem(
                GetJsonValue(json, "serviceName"),
                GetJsonValue(json, "trackingNumber"),
                GetJsonValue(json, "packageStatus"),
                GetJsonValue(json, "activityScan"),
                GetJsonValue(json, "shippedOrBilledDate"),
                GetJsonValue(json, "scheduledDeliveryDate"),
                GetJsonValue(json, "weight"),
                GetJsonValue(json, "city"),
                GetJsonValue(json, "state"), zip, refer);
        }

        public void PrintSearchStatus(int page, int totalFound, int row)
        {
            var worksheet = reoGridControl.CurrentWorksheet;
            worksheet.SuspendUIUpdates();
            const int col = 2;
            worksheet.Cells[row, col].Data = $"scanning page {page}; {totalFound} total founds";
            worksheet.Cells[row, col].Style.TextColor = Color.Red;
            worksheet.ResumeUIUpdates();
        }

        public void PrintSearchDetail(string zipcode, string fromDate, string toDate, string refer, int row)
        {
            var worksheet = reoGridControl.CurrentWorksheet;
            worksheet.SuspendUIUpdates();
            if (worksheet.MaxContentCol <= row) worksheet.RowCount += 200;
            const int col = 1;
            worksheet.Cells[row, col].Data = zipcode;
            worksheet.Cells[row, col].Style.TextColor = Color.Red;
            worksheet.Cells[row, col].Style.FontSize = 12;
            worksheet.Cells[row, col].Style.Bold = true;
            worksheet.Cells[row, col].Style.Underline = true;
            worksheet.Cells[row, col + 3].Data = refer;
            worksheet.Cells[row, col + 3].Style.TextColor = Color.Gray;
            worksheet.Cells[row, col + 4].Data = fromDate;
            worksheet.Cells[row, col + 5].Data = toDate;
            worksheet.ResumeUIUpdates();
        }

        public void PrintTrackDetail(UpsTrackItem item, int row)
        {
            var worksheet = reoGridControl.CurrentWorksheet;
            worksheet.SuspendUIUpdates();
            if (worksheet.MaxContentCol <= row) worksheet.RowCount += 200;

            const int col = 1;
            worksheet.Cells[row, col].Data = item.Track;
            worksheet.Cells[row, col].Style.TextColor = Color.Green;
            worksheet.Cells[row, col].Style.FontSize = 12;
            worksheet.Cells[row, col].Style.Bold = true;
            worksheet.Cells[row, col].Style.Underline = true;
            worksheet.Cells[row, col + 1].Data = item.ActivityScan;
            worksheet.Cells[row, col + 2].Data = item.Status;
            worksheet.Cells[row, col + 3].Data = item.ServiceName;
            worksheet.Cells[row, col + 4].Data = item.ShippedOrBilledDate;
            worksheet.Cells[row, col + 5].Data = item.ScheduledDeliveryDate;
            worksheet.Cells[row, col + 6].Data = item.Weight;
            worksheet.Cells[row, col + 7].Data = item.City;
            worksheet.Cells[row, col + 8].Data = item.State;
            worksheet.Cells[row, col + 9].Data = item.Zip;
            worksheet.Cells[row, col + 10].Data = item.Refer;
            //for (var i = 0; i < 9; i++) worksheet.AutoFitColumnWidth(col + i);
            worksheet.ResumeUIUpdates();
        }

        private CancellationTokenSource _cancel = null;

        private void ToolStripButtonSearch_Click(object sender, EventArgs e)
        {
            if (_cancel != null && !_cancel.IsCancellationRequested)
            {
                _cancel.Cancel();
                toolStripButtonSearch.Enabled = false;
                return;
            }

            toolStripButtonSearch.Text = @"stop";
            _cancel = new CancellationTokenSource();
            var zip = toolStripTextBoxDestZip.Text;
            var fromDate = toolStripDateTimeFromDate.Value.ToString("MM/dd/yyyy");
            var nowUs = TimeZoneInfo.ConvertTime(DateTime.Now,
                TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time"));
            var toDate = nowUs.ToString("MM/dd/yyyy");
            var maxTracks = int.Parse(toolStripTextBoxMaxTracks.Text);
            var totalPages = int.Parse(toolStripTextBoxPages.Text);
            Task.Factory.StartNew(() =>
            {
                var zipArr = zip.Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim());
                foreach (var zipcode in zipArr)
                {
                    if(_cancel.IsCancellationRequested) return;
                    var row = reoGridControl.CurrentWorksheet.MaxContentRow + 1;
                    var rowSearchDetail = row;
                    BeginInvoke((MethodInvoker) delegate
                    {
                        PrintSearchDetail(zipcode, fromDate, toDate, "x", rowSearchDetail);
                    });
                    var refer = 0;
                    var totalTracks = 0;
                    while (totalTracks < maxTracks && refer < totalPages)
                    {
                        if (_cancel.IsCancellationRequested) return;
                        refer++;
                        var tracks = SearchTracks(zipcode, fromDate, toDate, refer.ToString()).ToArray();
                        var rowDetail = row + totalTracks + 1;
                        var referDetail = refer;
                        tracks.AsParallel().Select((s, i) => (i, GetTrackDetail(zipcode, referDetail.ToString(), s)))
                            .ForAll(tuple =>
                            {
                                BeginInvoke((MethodInvoker) delegate
                                {
                                    PrintTrackDetail(tuple.Item2, rowDetail + tuple.Item1);
                                });
                            });
                        totalTracks += tracks.Length;
                        var referSearchStatus = refer;
                        var tracksSearchStatus = totalTracks;
                        BeginInvoke((MethodInvoker)delegate
                        {
                            PrintSearchStatus(referSearchStatus, tracksSearchStatus, rowSearchDetail);
                        });
                    }
                }
            }).ContinueWith(task =>
            {
                Invoke((MethodInvoker) delegate
                {
                    toolStripButtonSearch.Enabled = true;
                    toolStripButtonSearch.Text = @"search";
                    _cancel = null;
                });
            });
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            reoGridControl.Save(_excelFile, FileFormat.Excel2007, Encoding.UTF8);
            Process.Start(_excelFile);
        }

        private void Search_Load(object sender, EventArgs e)
        {
            var nowUs = TimeZoneInfo.ConvertTime(DateTime.Now,
                TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time"));
            toolStripDateTimeFromDate.Value = nowUs.AddDays(-1);
            toolStripDateTimeFromDate.AutoSize = false;
            toolStripDateTimeFromDate.Width = 75;
            toolStripDateTimeFromDate.AutoSize = true;
            if (!File.Exists(_excelFile)) return;
            try
            {
                reoGridControl.Load(_excelFile);
            }
            catch
            {
                //
            }
        }

        private void ToolStripButtonClear_Click(object sender, EventArgs e)
        {
            reoGridControl.Reset();
        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MaxTracks = toolStripTextBoxMaxTracks.Text;
            Properties.Settings.Default.Pages = toolStripTextBoxPages.Text;
            Properties.Settings.Default.Zipcode = toolStripTextBoxDestZip.Text;
            Properties.Settings.Default.Save();
        }
    }
}