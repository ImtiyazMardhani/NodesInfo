using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NodeStructure.Models;

namespace NodeStructure.Controllers
{
    public class NodesDetailController : Controller
    {
        private readonly AppDbContext _context;

        public NodesDetailController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NodesInfo
        public async Task<IActionResult> Index()
        {
            List<NodesList> nodesList = new List<NodesList>();
            NodesList Subnodes = new NodesList();
            var nodesparent = await _context.nodesInfo.Where(s => s.parentNodeId == 0).ToListAsync();
            foreach (var nodesMaster in nodesparent)
            {
                Subnodes = new NodesList();
                Subnodes.nodeId = nodesMaster.nodeId;
                Subnodes.nodeName = nodesMaster.nodeName;
                var nodeschild = await _context.nodesInfo.Where(s => s.parentNodeId == nodesMaster.nodeId).ToListAsync();
                List<SubNodesList> subNodesLists = new List<SubNodesList>();
                SubNodesList subList = new SubNodesList();
                foreach (var ChldNodes in nodeschild)
                {
                    subList = new SubNodesList();
                    subList.nodeId = ChldNodes.nodeId;
                    subList.nodeName = ChldNodes.nodeName;
                    subNodesLists.Add(subList);
                }
                Subnodes.childnodes = subNodesLists;
                nodesList.Add(Subnodes);
            }
            return View(nodesList);
        }

        
    }
}
