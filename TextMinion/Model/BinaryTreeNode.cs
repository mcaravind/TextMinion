using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMinion.Model
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode LeftNode { get; set; }
        public BinaryTreeNode RightNode { get; set; }
        public string Value { get; set; }
        public POS PosTag { get; set; }
    }
}
