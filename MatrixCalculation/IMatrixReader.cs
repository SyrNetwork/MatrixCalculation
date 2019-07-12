using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculation
{
    interface IMatrixReader
    {
        string Operation { get; set; }
        int[,] Matrix { get; set; }

        IEnumerable<int[,]> GetMatrix(string data);

        string GetMatrixOperation(string data);
    }
}
