using System.ComponentModel.DataAnnotations;

namespace NodeStructure.Models
{
    public class NodesInfo
    {
        [Key]
        public int nodeId { get; set; }
        public string nodeName { get; set; }
        public int parentNodeId { get; set; }
        public bool isActive { get; set; }
        public DateOnly startDate { get; set; }
    }
    public class NodesList
    {
        public int nodeId { get; set; }
        public string nodeName { get; set; }
        public List<SubNodesList> childnodes { get; set; }
    }
    public class SubNodesList
    {
        public int nodeId { get; set; }
        public string nodeName { get; set; }
    }
}
