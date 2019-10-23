namespace SGTwebAPI.Models {
    public class TodoItem {

        public long id { get; set; }
        public string Title { get; set; }
        public string url { get; set; }
        public string By { get; set; }
        public int time { get; set; }
        public long score { get; set; }
        public int commentCount { get; set; }
        /*
        public long id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; } */

    }
}