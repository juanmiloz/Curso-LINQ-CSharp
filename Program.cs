using System.Runtime.CompilerServices;

LinqQueries linqQueries = new();

//Toda la coleccion
//PrintValues(linqQueries.GetAllCollection());


//Libros despues del 2000
// PrintValues(linqQueries.BooksAfter2000());


//Libros con mas de 250 paginas y el titulo contenga in actionn
// PrintValues(linqQueries.BooksWithMoreThan250Pages());


//Absolutamente todos los libros tienen status
//Console.WriteLine($"Todos los libros tienen estatus? {linqQueries.BooksWithouthNullValueInStatus()}");

//Libros publicados en 2005
// Console.WriteLine($"Alguno de los libros fue publicado en 2005? {linqQueries.BooksPublishedIn2005(2005)}");

//libros de python
//PrintValues(linqQueries.GetBooksWithPython());

//Libros de Java ordenados ascendentemente por nombre
// PrintValues(linqQueries.OrderJavaBooksByNameAsc());


//Libors de mas de 450 paginas ordenados de manera descendente
// PrintValues(linqQueries.OrderByPagesNumbersDesc());

//Los primeros 3 libros con fecha de publicacion mas recientes y que esten categorizados en java
//PrintValues(linqQueries.TakeTopOfBooksMoreRecentlyWithJavaCategory());

//El 3er y 4to libro con mas de 400 paginas
//PrintValues(linqQueries.TakeThreeAndFourBookWithMoreThan400Pages());

//Obtener los 3 primeros libros filtrados con selectDisablePrivateReflectionAttribute
// PrintValues(linqQueries.Top3BooksWithTitleAndNumberOfPages());

//Cantidad de libros que tienen entre 200 y 500 paginas
// Console.WriteLine($"La cantidad de libros que tienen entre 200 y 500 paginas son {linqQueries.CountBookBetween200And500Pages()}");
// Console.WriteLine($"La cantidad de libros que tienen entre 200 y 500 paginas son {linqQueries.CountBookBetween200And500PagesLong()}");

//Retornar la fecha minima 
//Console.WriteLine($"La minima fecha de publicacion es {linqQueries.GetMinPublishDate()}");

//Retornar el mayor numero de paginas
//Console.WriteLine($"El libro que tiene el mayor numero de paginas tiene {linqQueries.GetMaxBookPages()}");

//Libro con menor cantidad de paginas mayor a 0
// var book = linqQueries.GetBookWithMinQuantityOfPageGreaterThan0();
// Console.WriteLine($"El libro con menor cantidad de paginas mayores a 0 es {book?.Title} con {book?.PageCount} paginas"); 


//Libro con fecha de publicacion mas reciente 
// var book = linqQueries.GetBookWithWithMostRecentPublishDate();
// Console.WriteLine($"El libro con fecha de publicacion mas reciente se llama {book?.Title} publicado el {book?.PublishedDate}");

//Suma de paginas entre 0 y 500
//Console.WriteLine($"El valor de la suma de las paginas entre 0 y 500 es: {linqQueries.SumPageCountOfBooksBetween0And500()}");

// Libros con fecha de publicacion mayor a 2015
//Console.WriteLine($"Los libros con fecha de publicacion mayor 2015 son: {linqQueries.GetNameOfBooksWithPublicationDateGreaterThan2015()}");

//El promedio de la cantidad de caracteres en los titulos de los libros
// Console.WriteLine($"El promedio de caracteres en los titulos de los libros es de {linqQueries.GetAverageOfCharacterTitle()}");


//El promedio de la cantidad de caracteres en los titulos de los libros
// Console.WriteLine($"El promedio de las paginas de los libros es de {linqQueries.GetAverageOfPages()}");


//Libros publicados a partir del 2000 agrupados por año
// PritnGroup(linqQueries.GetBooksAfter2000GroupedByYear());


//Diccionario de libros agrupados por la primera letra del titulo
// var dictionaryLookUp = linqQueries.BooksDictionaryByChar();
// PritnDictionary(dictionaryLookUp, 'A');

//Libros filtrados con la clausula join 
PrintValues(linqQueries.GetJoinBetweenBooksWithMoreThan500PagesAndPublishAfter2005());


void PrintValues (IEnumerable<Book> bookList){
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. paginas", "Fecha publicacion");
    foreach(var item in bookList){
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title,item.PageCount, item.PublishedDate?.ToShortDateString());
    }
}


void PritnGroup(IEnumerable<IGrouping<int?, Book>> booksList){
    foreach(var group in booksList){
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {group.Key}");
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. paginas", "Fecha publicacion");
        foreach(var item in group){
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title,item.PageCount, item.PublishedDate?.ToShortDateString());
        }
    }
}

void PritnDictionary(ILookup<char?, Book> booksList, char letter){
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. paginas", "Fecha publicacion");
    foreach(var item in booksList[letter]){
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title,item.PageCount, item.PublishedDate?.ToShortDateString());
    }
}