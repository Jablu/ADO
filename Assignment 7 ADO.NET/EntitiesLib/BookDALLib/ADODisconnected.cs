using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLib;
using System.Data.SqlClient;
using System.Data;

namespace BookDALLib
{
    public class ADODisconnected
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;

        public ADODisconnected() {

            con = new SqlConnection();
            con.ConnectionString = "Data Source=BLRLCVEDANTA;Initial Catalog=ADO_CONNECT;Integrated Security=True";

            //Configure Data Adapter
            da = new SqlDataAdapter();
            cmd = new SqlCommand();

            cmd.CommandText = "SELECT * from BookDetails";
            cmd.Connection = con;

            //Attach command with Data Adapter
            da.SelectCommand = cmd;

            //Configure Dataset
            ds = new DataSet();
            da.Fill(ds, "BookDetails");
        
        }
        public void InsertBooks (BookDetails bd)
        {
            DataRow row = ds.Tables[0].NewRow();

            row[0] = bd.Bname;
            row[1] = bd.Bid;
            row[2] = bd.Aname;
            row[3] = bd.Pname;
            row[4] = bd.Bcopies;
            row[5] = bd.Bprice;

            ds.Tables[0].Rows.Add(row);

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "BookDetails");
        }
        public List<BookDetails> ShowAllBooks()
        {

            List<BookDetails> bookList = new List<BookDetails>();
            //Add all the records from dataset
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                BookDetails bd = new BookDetails
                {
                    Bname = row[0].ToString(),
                    Bid = (int)row[1],
                    Aname = row[2].ToString(),
                    Pname = row[3].ToString(),
                    Bcopies = (int)row[4],
                    Bprice = (int)row[5]
                };
                bookList.Add(bd);
            }

            return bookList;

        }
        public List<BookDetails> FindMyBooks(String search)
        {
            List<BookDetails> bookList2 = new List<BookDetails>();

            DataRow[] rows = ds.Tables[0].Select("bname = '" + search + "' OR bname Like '%" + search + "%'");

            if (rows.Count() == 0)
            {
                Console.WriteLine("Can not find anything similar searching "+ search);    
            }

            //Add all the records from dataset
            foreach (DataRow row in rows)
            {

                BookDetails bd = new BookDetails
                {
                    Bname = row[0].ToString(),
                    Bid = (int)row[1],
                    Aname = row[2].ToString(),
                    Pname = row[3].ToString(),
                    Bcopies = (int)row[4],
                    Bprice = (int)row[5]
                };
                bookList2.Add(bd);
            }

            return bookList2;
        }

    }
}
