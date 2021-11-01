using System;

namespace Schmansible.Models
{
    public class Job
    {
        public int Id { get; set; }
        public Inventory Inventory { get; set; }
        public PlayBook Playbook { get; set; }
        public string Output { get; set; }
        public DateTime LastRun { get; set; }
    }
}
