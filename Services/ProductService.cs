using lrnaz204.Models;
using System.Data.SqlClient;
namespace lrnaz204.Services
{
    public class ProductService
    {
        private static string db_source = "lrn204ser.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_Password = "Riskey@2012345";
        private static string db_Database = "lrn204";

        private SqlConnection getconnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID= db_user;
            _builder.Password = db_Password;
            _builder.InitialCatalog= db_Database;
            return new SqlConnection( _builder.ConnectionString );
        }

        public List<Product> GetProducts() 
        {
            SqlConnection conn = getconnection();
            List<Product> _productlist = new List<Product>();
            string statement = "SELECT ProductID,ProductName,Quantity FROM Products";
            conn.Open();
            SqlCommand cmd=new SqlCommand(statement,conn);
            using(SqlDataReader reader=cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                   Product product = new Product();
                    {
                        product.ProductID = reader.GetInt32(0);
                        product.ProductName = reader.GetString(1);
                        product.Quantity = reader.GetInt32(2);  
                    };
                    _productlist.Add(product);
                }
             }
            conn.Close();
            return _productlist;
        }
    }
}
