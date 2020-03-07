using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systemAnalyze3
{
    class GraphOperator
    {
        List<List<int>> matrix;
        int count;
        List<HashSet<int>> setList = new List<HashSet<int>>();
        public GraphOperator(List<List<int>> _m, int _c)
        {
            matrix = _m;
            count = _c;
            createDecompositionLists();
        }

        private List<int> getOutcomingNodes(int num)
        {
            if (num >= count) return null;
            return matrix[num];
        }
        private List<int> getIncomingNodes(int num)
        {
            if (num >= count) return null;
            List<int> incList = new List<int>();
            for (int i = 0; i != count; i++)
            {
                if (matrix[i].Contains(num))
                    incList.Add(i);
            }
            return incList;
        }

        public List<HashSet<int>> createDecompositionLists()
        {
            List<HashSet<int>> levels = new List<HashSet<int>>();
            HashSet<int> freeTops = new HashSet<int>();
            for(int j=0; j!= count; j++)
            {
                freeTops.Add(j);
            }
            List<int> outGroup = new List<int>();
            List<int> inGroup = new List<int>();
            while (freeTops.Count != 0)
            {
                int coreElem = freeTops.Min();
                int i = 0;
                outGroup.Clear();
                outGroup.Add(coreElem);
                do
                {
                    List<int> outNodes = getOutcomingNodes(outGroup[i]);
                    outGroup = outGroup.Union(outNodes).ToList() ;
                    i++;
                }
                while (i != outGroup.Count);
                inGroup.Clear();
                inGroup.Add(coreElem);
                i = 0;
                do
                {
                    List<int> inNodes = getIncomingNodes(inGroup[i]);
                    inGroup = inGroup.Union(inNodes).ToList();
                    i++;
                }
                while (i != inGroup.Count);
                List<int> intersectionGroup = outGroup.Intersect(inGroup).ToList();
                HashSet<int> levelgroup = new HashSet<int>(intersectionGroup);
                levels.Add(levelgroup);
                freeTops = new HashSet<int>(freeTops.Except(levelgroup));
            }
            return levels;
        }
    }
}
