using System;

namespace UpsTrack
{
    public class UpsTrackItem
    {
        public string ServiceName { get; }
        public string Track { get; }
        public string Status { get; }//packageStatus=Shipment Ready for UPS
        public string ActivityScan { get; }
        public string ShippedOrBilledDate { get; }
        public string ScheduledDeliveryDate { get; }
        public string Weight { get; }
        public string City { get; }
        public string State { get; }
        public string Zip { get; }
        public string Refer { get; }

        public UpsTrackItem(string serviceName,
            string track,
            string status,
            string activityScan,
            string shippedOrBilledDate,
            string scheduledDeliveryDate,
            string weight,
            string city,
            string state, string zip, string refer)
        {
            ServiceName = serviceName;
            Track = track;
            Status = status;
            ActivityScan = activityScan;
            ShippedOrBilledDate = shippedOrBilledDate;
            ScheduledDeliveryDate = scheduledDeliveryDate;
            Weight = weight;
            City = city;
            State = state;
            Zip = zip;
            Refer = refer;
        }
    }
}