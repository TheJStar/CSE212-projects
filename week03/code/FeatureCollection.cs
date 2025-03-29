public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    public string type { get; set; }
    public Metadata metadata { get; set; }
    public Features[] features { get; set; }

    public class Metadata () {
        public double generated { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string api { get; set; }
        public int count { get; set; }
    }

    public class Features () {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties () {
        public float mag { get; set; }
        public string place { get; set; }
        public double time { get; set; }
        public double updated { get; set; }
        public double? tz { get; set; }
        public string url { get; set; }
        public string details { get; set; }
        public float? felt { get; set; }
        public float? cdi { get; set; }
        public float? mmi { get; set; }
        public string? alert { get; set; }
        public string status { get; set; }
        public int tsunami { get; set; }
        public int sig { get; set; }
        public string net { get; set; }
        public string code { get; set; }
        public string ids { get; set; }
        public string sources { get; set; }
        public string types { get; set; }
        public int? nst { get; set; }
        public float? dmin { get; set; }
        public float? rms { get; set; }
        public double? gap { get; set; }
        public string magType { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public Geometry geometry { get; set; }
        public string id { get; set; }
    }
    public class Geometry () {
        public string type { get; set; }
        public double[] coordinates { get; set; }
    }
    // Create additional classes as necessary
}