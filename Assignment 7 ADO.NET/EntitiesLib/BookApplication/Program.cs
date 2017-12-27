using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitiesLib;
using BookBLL;

namespace BookApplication
{
    class Program
    {
        static void Main(string[] args)
        {


            BLL myBll = new BLL();

            //string bn, an, pn;
            //int bi, bc, bp;

            //Show All
            List<BookDetails> bookList = myBll.GetAllBooks();

            List<BookDetails> bookList2 = myBll.GetAllBooks();
            foreach (var r in bookList)
            {
                Console.WriteLine(r.Bname + "\t" + r.Bid + "\t" + r.Aname + "\t" + r.Pname + "\t" + r.Bcopies + "\t" + r.Bprice + "\t");
            }

            BookDetails bookDetails = new BookDetails();
            BookDetails bookDetails2 = new BookDetails();

            ////Show All Books
            //Console.Write("Enter Book Name: ");
            //bookDetails.Bname = Console.ReadLine();

            //Console.Write("Enter Book ID: ");
            //bookDetails.Bid = int.Parse(Console.ReadLine());

            //Console.Write("Enter Author Name: ");
            //bookDetails.Aname = Console.ReadLine();

            //Console.Write("Enter Publisher Name: ");
            //bookDetails.Pname = Console.ReadLine();

            //Console.Write("Enter Copies: ");
            //bookDetails.Bcopies = int.Parse(Console.ReadLine());

            //Console.Write("Enter Price: ");
            //bookDetails.Bprice = int.Parse(Console.ReadLine());

            ////Inserting
            //myBll.CreateBooks(bookDetails);


            

            //Search Book
            Console.Write("Search Your Book: ");
            string keyword = Console.ReadLine();
            bookList2 = myBll.SearchBooks(keyword);
            foreach (var r in bookList2)
            {
                Console.WriteLine(r.Bname + "\t" + r.Bid + "\t" + r.Aname + "\t" + r.Pname + "\t" + r.Bcopies + "\t" + r.Bprice + "\t");
            }

        }
    }
}
