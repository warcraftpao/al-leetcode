namespace Leetcode.Matrix
{
    //copy的，提示强调的是O(m+n) space 不是时间复杂度
    public class SetMatrixZero
    {
        public  static  void Set(int[,] matrix)
        {
            int rownum = matrix.GetLength(0);
            if (rownum == 0) return;
            int colnum = matrix.GetLength(1);
            if (colnum == 0) return;

            bool hasZeroFirstRow = false;
            bool hasZeroFirstColumn = false;

            // 因为第一行第一列本身可能没有0，虽然某些位因为其他行列被设0，但是不应该影响其他位
            // Does first row have zero?
            for (int j = 0; j < colnum; ++j)
                if (matrix[0,j] == 0)
                {
                    hasZeroFirstRow = true;
                    break;
                }

            // Does first column have zero?
            for (int i = 0; i < rownum; ++i)
                if (matrix[i,0] == 0)
                {
                    hasZeroFirstColumn = true;
                    break;
                }

            // find zeroes and store the info in first row and column
            //循环是从第二行第二列开始判定的，把第一行第一列作为存储信息的地方，没有0就不修改值
            for (int i = 1; i < matrix.GetLength(0); ++i)
                for (int j = 1; j < matrix.GetLength(1); ++j)
                    if (matrix[i,j] == 0)
                    {
                        matrix[i,0] = 0;
                        matrix[0,j] = 0;
                    }
            

            // set zeroes except the first row and column，根据第一行第一列信息设0
            for (int i = 1; i < matrix.GetLength(0); ++i)
                for (int j = 1; j < matrix.GetLength(1); ++j)
                    if (matrix[i,0] == 0 || matrix[0,j] == 0) matrix[i,j] = 0;

            // set zeroes for first row and column if needed
            if (hasZeroFirstRow)
                for (int j = 0; j < colnum; ++j)
                    matrix[0,j] = 0;

            if (hasZeroFirstColumn)
                for (int i = 0; i < rownum; ++i)
                    matrix[i,0] = 0;
            
        }
    }
}
