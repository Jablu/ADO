using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitiesLib;
using BookDALLib;

namespace BookBLL
{
    public class BLL
    {

        ADODisconnected dalCon;
        public BLL()
        {
            dalCon = new ADODisconnected();
        }
        public List<BookDetails> GetAllBooks()
        {
            List<BookDetails> bookList = dalCon.ShowAllBooks();
            return bookList;
        }
        public void CreateBooks(BookDetails bookDetails)
        {
            dalCon.InsertBooks(bookDetails);
        }
        public List<BookDetails> SearchBooks(string search)
        {
            List<BookDetails> bookList = dalCon.FindMyBooks(search);
            return bookList;
        }


    }
}
