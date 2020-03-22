using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systemAnalyze3
{
    class GraphOperator
    {
        public List<List<int>> matrix, subsystemMatrix;
        public int count, bounds;
        public List<HashSet<int>> setList;
        public GraphOperator(List<List<int>> _m, int _c)
        {
            matrix = _m;
            count = _c;
            setList = createDecompositionLists();
            subsystemMatrix = createMatrixForSubsystems();
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

        private List<HashSet<int>> createDecompositionLists()
        {
            List<HashSet<int>> levels = new List<HashSet<int>>();
            // Составляем список свободных вершин (не входящих ни в одну из подсистем)
            HashSet<int> freeTops = new HashSet<int>();
            for(int j=0; j!= count; j++)
            {
                freeTops.Add(j);
            }
            List<int> outGroup = new List<int>();
            List<int> inGroup = new List<int>();
            while (freeTops.Count != 0)
            {
                // выбор минимального элемента из свободных
                int coreElem = freeTops.Min();
                int i = 0;
                outGroup.Clear();
                outGroup.Add(coreElem);
                //Для всех элементов, входящих в список исходящих вершин
                //выбирается список исходящих из них и также добавляется в   этот список
                // строим множество R
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
                //аналогично для входящих вершин
                //строим множество Q
                do
                {
                    List<int> inNodes = getIncomingNodes(inGroup[i]);
                    inGroup = inGroup.Union(inNodes).ToList();
                    i++;
                }
                while (i != inGroup.Count);
                //находим пересечение G множетств 
                List<int> intersectionGroup = outGroup.Intersect(inGroup).ToList();
                HashSet<int> levelgroup = new HashSet<int>(intersectionGroup);
                // добавляем новую подсистему
                levels.Add(levelgroup);
                //исключаем из массива свободных вершин все вершины, включенные в найденную подсистему
                freeTops = new HashSet<int>(freeTops.Except(levelgroup));
            }
            return levels;
        }

        private bool isGroupHasPaths(List<int> from, List<int> to)
        {
            foreach (int source in from)
            {
                List<int> outcomingNodes = getOutcomingNodes(source);
                if (outcomingNodes.Intersect(to).ToList().Count != 0) return true;
            }
            return false;
        }

        private List<List<int>> createMatrixForSubsystems()
        {
            List<List<int>> matrixSubsystemPaths = new List<List<int>>();
            for(int i=0; i!= setList.Count; ++i)
            {
                List<int> incomingPathToSubsystems = new List<int>();
                for (int j=0; j!= setList.Count; ++j)
                {
                    if (i != j)
                    {
                        if (isGroupHasPaths(setList[i].ToList(), setList[j].ToList()))
                            incomingPathToSubsystems.Add(j);
                    }
                }
                matrixSubsystemPaths.Add(incomingPathToSubsystems);
            }
            return matrixSubsystemPaths;
        }

        public List<List<KeyValuePair<int, int>>> AtoBMatrix(List<List<int>> Amatrix)
        {
            List<List<KeyValuePair<int, int>>> Bmatrix = new List<List<KeyValuePair<int, int>>>();
            for (int i=0; i!= Amatrix.Count; ++i)
            {
                Bmatrix.Add(new List<KeyValuePair<int, int>>());
            }
            int num = 0;
            for (int i = 0; i != Amatrix.Count; ++i)
            {
                for (int j =0; j!= Amatrix[i].Count; ++j)
                {
                    Bmatrix[i].Add(new KeyValuePair<int, int>(num, 1));
                    Bmatrix[Amatrix[i][j]].Add(new KeyValuePair<int, int>(num, -1));
                    ++num;
                }
            }
            bounds = num;
            return Bmatrix;
        }
    }
}
