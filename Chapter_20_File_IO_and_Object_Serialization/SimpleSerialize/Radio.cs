using System;

namespace SimpleSerialize
{
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofer;
        public double[] stationPresets;

        [NonSerialized] 
        public string radioID = "XF-552RR6";
    }
}
