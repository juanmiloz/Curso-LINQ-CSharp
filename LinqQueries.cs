using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

public class LinqQueries
{

    private List<Book> booksCollection = [];

    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> GetAllCollection()
    {
        return booksCollection;
    }

    public IEnumerable<Book> BooksAfter2000()
    {
        // return booksCollection.Where(p => p.PublishedDate?.Year > 2000); // <-- extension method

        return from b in booksCollection where b.PublishedDate?.Year > 2000 select b; //<--Query expression
    }


    public IEnumerable<Book> BooksWithMoreThan250Pages()
    {
        //Extend Method
        return booksCollection.Where(b => b.PageCount > 250 && b.Title?.Contains("in Action") == true);

        //Query expression
        //return from b in booksCollection where b.PageCount > 250 && b.Title?.Contains("in Action") == true select b;
    }


    public bool BooksWithouthNullValueInStatus()
    {
        return booksCollection.All(b => b.Status != String.Empty);
    }


    public bool BooksPublishedIn2005(int year)
    {
        return booksCollection.Any(b => b.PublishedDate?.Year == year);
    }

    public IEnumerable<Book> GetBooksWithPython()
    {
        return booksCollection.Where(b => b.Categories.Contains("Python"));
    }

    public IEnumerable<Book> OrderJavaBooksByNameAsc()
    {
        return booksCollection.Where(b => b.Categories.Contains("Java")).OrderBy(b => b.Title);
    }

    public IEnumerable<Book> OrderByPagesNumbersDesc()
    {
        return booksCollection.Where(b => b.PageCount > 450).OrderByDescending(b => b.PageCount);
    }

    public IEnumerable<Book> TakeTopOfBooksMoreRecentlyWithJavaCategory()
    {
        return booksCollection.Where(b => b.Categories.Contains("Java")).OrderByDescending(b => b.PublishedDate).Take(3);

        //return booksCollection.Where(b => b.Categories.Contains("Java")).OrderBy(b => b.PublishedDate).TakeLast(3);
    }

    public IEnumerable<Book> TakeThreeAndFourBookWithMoreThan400Pages()
    {
        return booksCollection.Where(b => b.PageCount > 400).Take(4).Skip(2);
    }

    public IEnumerable<Book> Top3BooksWithTitleAndNumberOfPages()
    {
        return booksCollection.Take(3).Select(b => new Book() { Title = b.Title, PageCount = b.PageCount });
    }


    public int CountBookBetween200And500Pages()
    {
        return booksCollection.Count(b => b.PageCount >= 200 && b.PageCount <= 500);
    }

    public long CountBookBetween200And500PagesLong()
    {
        return booksCollection.LongCount(b => b.PageCount >= 200 && b.PageCount <= 500);
    }

    public DateTime? GetMinPublishDate()
    {
        return booksCollection.Min(b => b.PublishedDate);
    }

    public int? GetMaxBookPages()
    {
        return booksCollection.Max(b => b.PageCount);
    }

    public Book? GetBookWithMinQuantityOfPageGreaterThan0()
    {
        return booksCollection.Where(b => b.PageCount > 0).MinBy(b => b.PageCount);
    }


    public Book? GetBookWithWithMostRecentPublishDate()
    {
        return booksCollection.MinBy(b => b.PublishedDate);
    }

    public int? SumPageCountOfBooksBetween0And500()
    {
        return booksCollection.Where(b => b.PageCount >= 0 && b.PageCount <= 500).Sum(b => b.PageCount);
    }


    public string GetNameOfBooksWithPublicationDateGreaterThan2015()
    {
        return booksCollection
        .Where(b => b.PublishedDate?.Year > 2015)
        .Aggregate("", (TitulosLibros, next) =>
        {
            if (TitulosLibros != "")
                TitulosLibros += " - " + next.Title;
            else
                TitulosLibros += next.Title;

            return TitulosLibros;
        });
    }


    public double? GetAverageOfCharacterTitle()
    {
        return booksCollection.Average(b => b.Title?.Length);
    }

    public double? GetAverageOfPages()
    {
        return booksCollection.Where(b => b.PageCount > 0).Average(b => b.PageCount);
    }

    public IEnumerable<IGrouping<int?, Book>> GetBooksAfter2000GroupedByYear(){
        return booksCollection.Where(b => b.PublishedDate?.Year >= 2000).GroupBy(b => b.PublishedDate?.Year);
    }

    public ILookup<char?, Book> BooksDictionaryByChar(){
        return booksCollection.ToLookup(b => b.Title?[0], b => b);
    }


    public IEnumerable<Book> GetJoinBetweenBooksWithMoreThan500PagesAndPublishAfter2005(){
        var booksWithMoreThan500Pages = booksCollection.Where(b => b.PageCount > 500);
        var booksWithPublishDateAfter2005 = booksCollection.Where(b => b.PublishedDate?.Year > 2005);

        return booksWithMoreThan500Pages.Join(booksWithPublishDateAfter2005, x => x.Title, y => y.Title, (x, y) => x);
    }

}