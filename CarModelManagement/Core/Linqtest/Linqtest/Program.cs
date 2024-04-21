
using Linqtest.Model;
using Microsoft.VisualBasic;
using System.Linq;
Console.WriteLine("Hello, World!");

List<Author> authors = new List<Author>
{ 
    new Author {AuthorId=1,AuthorName="John Doe" },
    new Author {AuthorId=2,AuthorName="Jane Smith" },
    new Author {AuthorId=3,AuthorName="Bob Johnson" }
};

List<Book> books = new List<Book>
{
    new Book { BookId=1,Title="The Art of Programming",AuthorId=1,isAvailable=true,price=100 },
    new Book { BookId=2,Title="Data Science Essentials",AuthorId=1,isAvailable=false,price=1000 },
    new Book { BookId=3,Title="Fictional Adventures",AuthorId=2,isAvailable=true,price=1000},
    new Book { BookId=4,Title="LINQ Mastery",AuthorId=2,isAvailable=true ,price=1000},
    new Book { BookId=5,Title="Advanced C# techniques",AuthorId=3,isAvailable=false,price=450 }
};

List<Genre> genres = new List<Genre>
{
      new Genre { GenreId=1,GenreName="Science Fiction"},
      new Genre { GenreId=2,GenreName="programming"},
       new Genre { GenreId=3,GenreName="Data Science"},
};

List<Bookgenre> bookgenres = new List<Bookgenre>
{
    new Bookgenre { BookId=1 ,GenreId=2},
    new Bookgenre { BookId=2 ,GenreId=2},
    new Bookgenre { BookId=3 ,GenreId=1},
    new Bookgenre { BookId=3 ,GenreId=3},
    new Bookgenre { BookId=4 ,GenreId=2},
    new Bookgenre { BookId=5 ,GenreId=2},

};

List<borrowing> borrowings = new List<borrowing>
{
    new borrowing {BorrowingId=1,BookId=1,BorrowDate=new DateTime(2024,1,1),Returndate=new DateTime(2024,1,10)},
    new borrowing {BorrowingId=2,BookId=3,BorrowDate=new DateTime(2024,1,5),Returndate=null},
    new borrowing {BorrowingId=3,BookId=4,BorrowDate=new DateTime(2024,1,3),Returndate=new DateTime(2024,1,8)},
};

//Ans ----  1:

//var ans = authors.Join(
//    books,
//    auth => auth.AuthorId,
//    book => book.AuthorId,
//    (auth, book) => new
//    {
//        bookname = book.Title,
//        Authorname = auth.AuthorName,
//        IsAvailable = book.isAvailable
//    }).GroupBy(s => s.Authorname).Where(x => x.All(y => y.IsAvailable) && x.Count() >=  2);

//foreach (var i in ans)
//{

//    //Console.WriteLine(i.Key);
//    int count = 0;
//    foreach (var j in i)
//    {
//        count++;
//    }
//    if (count >= 2)
//    {
//        Console.WriteLine(i.Key);
//    }
//}



//Ans-------- 2

//var ans = books.Join(
//        borrowings,
//        a => a.BookId,
//        b => b.BookId,
//        (a, b) => new
//        {
//            bookname = a.Title,
//            borrowdate = b.BorrowDate,
//            returndate = b.Returndate,
//            Duration = b.Returndate - b.BorrowDate
//        }).Where(x => x.returndate != null).OrderByDescending(x => x.Duration).FirstOrDefault();

//string name = "";
//TimeSpan ans5 = TimeSpan.Zero;
//foreach (var item in ans)
//{
//    if (item.returndate == null)
//    {
//        DateTime dateTime = DateTime.Now;
//        TimeSpan temp = (TimeSpan)(dateTime - item.borrowdate);
//        if (temp > ans5)
//        {
//            name = item.bookname;
//            ans5 = temp;
//        }
//    }
//    else
//    {
//        TimeSpan temp = (TimeSpan)(item.returndate - item.borrowdate);
//        if (temp > ans5)
//        {
//            name = item.bookname;
//            ans5 = temp;
//        }
//    }
//}
//Console.WriteLine(name);


//Ans---------- 3:

//var ans = books.Join(
//    borrowings,
//    boo => boo.BookId,
//    borrow => borrow.BookId,
//    (boo, borrow) => new
//    {
//        bookname = boo.Title,
//        bookid = boo.BookId,
//    }).GroupBy(x => x.bookid);

var ans1 = from s in books
           join m in borrowings
           on s.BookId equals m.BookId
           into Title
           from b in Title.DefaultIfEmpty()
           select new
           {
               BookName = s,
               Borrowing = b
           };

var ans2 = ans1
    .Select(m => new
    {
        BookName = m.BookName.Title,
        id = m.Borrowing
    })
    .Where(x => x.id == null);

Console.WriteLine("hello");


//List<Book> ans1 = books;
//foreach (var book in ans)
//{
//    var temp = book.Key;
//    var data = ans1.Find(x => x.BookId == temp);
//    //var bb=books.FirstOrDefault(x=>x.BookId==temp);
//    //if (bb == null)
//    //{ 
//    //    ans1.Add()
//    //}
//    ans1.Remove(data);
//}

//foreach (var item in ans1)
//{
//    Console.WriteLine(item.Title);
//}


//Ans ------- 4:

//var ans = authors.Join(
//   books,
//   auth => auth.AuthorId,
//   book => book.AuthorId,
//   (auth, book) => new
//   {
//       bookname = book.Title,
//       Authorname = auth.AuthorName,
//       bookprice = book.price
//   }).GroupBy(s => s.Authorname).Select(g => new
//   {
//       AuthorName = g.Key,
//       AverageBookPrice = g.Average(x => x.bookprice)
//   }).OrderByDescending(x => x.AverageBookPrice).FirstOrDefault();
//Console.WriteLine(ans);

//var avg = 0;
//var answer = "";
//foreach (var i in ans)
//{
//    var name = i.Key;
//    var count = 0;
//    var temp = 0;
//    foreach (var j in i)
//    {
//        count++;
//        temp = (int)(j.bookprice + temp) ;
//    }
//    temp = temp / count;

//    if (temp > avg)
//    {
//        answer = name;
//        //Console.WriteLine(answer);
//        //Console.WriteLine(temp);
//        avg = temp;
//    }

//}
//Console.WriteLine(answer);


//Ans ------- 5;


//var ans = authors.Join(
//   books,
//   auth => auth.AuthorId,
//   book => book.AuthorId,
//   (auth, book) => new
//   {
//       bookname = book.Title,
//       Authorname = auth.AuthorName,
//       bookprice = book.price,
//       Authorid = auth.AuthorId,
//       Bookid = book.BookId,
//   }).Join(
//      bookgenres,
//      a => a.Bookid,
//      b => b.BookId,
//      (a, b) => new
//      {
//          authorname = a.Authorname,
//          genre = b.GenreId,
//      }).GroupBy(x => x.authorname).Select(a => new
//      {
//          authorname = a.Key,
//          num = a.Distinct().Count(),
//      }).Where(n => n.num >=3);
//Console.WriteLine(ans);


//List<string> ans2 = new List<string>();
//foreach (var j in ans1)
//{
//    int count = 0;
//    var tempp = j.OrderByDescending(x => x.genre);
//    var temp = -1;
//    foreach (var item in tempp)
//    {

//        if (temp != item.genre)
//        {
//            count++;
//        }
//        temp = item.genre;

//    }
//    if (count >= 3)
//    {
//        ans2.Add(j.Key);
//    }
//}
//foreach (var item in ans2)
//{
//    Console.WriteLine(item);
//}

//Ans ---------- 6;


//var ans = books
//    .Join(
//        bookgenres,
//        boo => boo.BookId,
//        boogen => boogen.BookId,
//        (gen, boogen) => new
//        {
//            bookid = gen.BookId,
//            genreid = boogen.GenreId,
//        }).Join(
//        borrowings,
//        a => a.bookid,
//        b => b.BookId,
//        (a, b) => new
//        {
//            bogen = a.genreid,
//        }).GroupBy(x => x.bogen);

//var ans1 = ans
//    .Select(m => new
//    {
//        genername = m.Key,
//        bookcount = m.Count()
//    })
//    .Where(x => x.bookcount == ans.Max(y => y.Count())); 

//Console.WriteLine(ans);

//int ans1 = 0;
//int count = 0;
//foreach (var i in ans)
//{
//    int cn = 0;

//    foreach (var item in i)
//    {
//        cn++;
//    }
//    if (cn > count)
//    {
//        ans1 = i.Key;
//        count = cn;
//    }
//}

//foreach (var i in genres)
//{
//    if (i.GenreId == ans1)
//    {
//        Console.WriteLine(i.GenreName);
//        break;
//    }
//}


//ans ---------7;

//var ans = books.Join(
//        borrowings,
//        a => a.BookId,
//        b => b.BookId,
//        (a, b) => new
//        {
//            bookname = a.Title,
//        }).GroupBy(x => x.bookname);

//var ans1 = ans.Select(m => new
//{
//    bookname = m.Key,
//    countbook = m.Count(),
//}).Where(x => x.countbook == ans.Max(y => y.Count()));
//Console.WriteLine(ans1);

//string ans1 = "";
//int count = 0;
//foreach (var i in ans)
//{
//    int cn = 0;

//    foreach (var item in i)
//    {
//        cn++;
//    }
//    if (cn > count)
//    {
//        ans1 = i.Key;
//        count = cn;
//    }
//}

//Console.WriteLine(ans1);
