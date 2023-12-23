using System;
using System.Collections.Generic;

public class Student : IDisposable
{
    private bool disposed = false;

    // Simulated managed resource
    private List<string> courses;

    // Simulated unmanaged resource
    private IntPtr unmanagedResource;

    public Student(string name)
    {
        courses = new List<string>();
        unmanagedResource = IntPtr.Zero; // Simulated unmanaged resource allocation
        Console.WriteLine($"{name} instance created.");
    }

    public void EnrollInCourse(string courseName)
    {
        courses.Add(courseName);
        Console.WriteLine($"{courseName} enrolled.");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); //This method call informs the garbage collector that finalization (the execution of the finalizer, ~Student()) for the object is not necessary since the resources have already been properly released during explicit disposal.
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Release managed resources here
                courses.Clear();
                Console.WriteLine("Courses cleared.");
            }

            // Release unmanaged resources here
            if (unmanagedResource != IntPtr.Zero) //unmanaged wont be collecred by garbage collector and better to manually dispose
            {
                // Simulated unmanaged resource release
                Console.WriteLine("Unmanaged resources released.");
                unmanagedResource = IntPtr.Zero;
            }

            disposed = true;
        }
    }

    //if developer forgets to call dispose finalizer that is ~studetn will be called which will remove the 
    //object.  And Dispose is set to false as managed data is already disposed it will dispose unmanaged data alone by calling dispose method
    ~Student()
    {
        Console.WriteLine("Finalizer called.");
        Dispose(false);
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student("John");

        // Enroll the student in some courses
        student.EnrollInCourse("Math");
        student.EnrollInCourse("History");

        // Now, manually call Dispose to release resources
        student.Dispose();

        Console.WriteLine("Resources released manually.");
    }
}

#region Program flow

/*

Firstly an instance of student is create will will create both managed and unmanaged object.
And then student in enrolled which will add data to managed list.

Now we are explicitly calling student.dispose which will call  public void Dispose() and where
Dispose(true) is called with true and since disposed = false initially it will clean the managed and unmanaged
object.  Now since object are release we can ask garbage collector not to run using GC.SuppressFinalize(this);

Now let suppose developer is not calling dispose then garbage collector will be called that is  ~Student()
and it will release the managed data.  Now it is going to call  Dispose(false) to release unmanaged data
as unmanaged data is not released by the garbage collector


 
 */

#endregion