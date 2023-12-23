//using System;

//namespace DynamicExample
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            dynamic d = 1; // type: dynamic {int}

//            var testSum = d + 3; // type: dynamic {int}

//            d = 2.0;
//        type: dynamic { double}
//            var i = 2; // type: int

//            #region note
//            DummyMethod(d) this wont throw any error because
//             dynamic type will be resolved at run time and we can only get runtime error.
//             But this wont be the case with int i as it is strongly typed
//            #endregion

//            DummyMethod(i);

//                void DummyMethod(string a)
//                {
//                    Console.WriteLine(a);
//                }
//                #region notes

//                /*
//                 when you create dynamic object it wont get any  intellisense.  You can check it using dot
//                use i. will give intellisence
//                but d. wont as d in dynamic

//                 */

//                #endregion


//                Console.WriteLine($"d: {d}, testSum: {testSum}, i: {i}");
//                Console.WriteLine(s);



//            }
//        }
//    }

using System;
using Microsoft.Office.Interop.Word;

namespace DynamicCOMExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Word application
            dynamic wordApp = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
            wordApp.Visible = true;

            // Add a new document
            dynamic document = wordApp.Documents.Add();

            // Write content to the document
            dynamic paragraph = document.Paragraphs.Add();
            paragraph.Range.Text = "Hello from dynamic COM! This is a new document.";

            // Save the document on the D: drive
            string filePath = @"D:\MyNewDocument.docx";
            document.SaveAs(filePath);

            // Close Word
            wordApp.Quit();

            Console.WriteLine("Document saved on D:. Press any key to exit.");
            Console.ReadKey();



        }
    }
}


