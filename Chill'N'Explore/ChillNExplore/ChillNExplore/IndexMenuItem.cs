using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillNExplore
{

    public class IndexMenuItem
    {
        public IndexMenuItem()
        {
            TargetType = typeof(IndexDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}