using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

struct StudentRequest
{
    public string StudentNumber;
    public string StudentName;
    public string RequestType;
}

struct Operation
{
    public string Description;
}

class Program
{
    static void Main()
    {
        Dictionary<string, Student> students = new Dictionary<string, Student>();
        Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();
        Stack<Operation> operationStack = new Stack<Operation>();

        int initialChoice = 0;

        while (initialChoice != 3)
        {
            Console.WriteLine("        STUDENT RECORD MANAGEMENT       ");

            Console.WriteLine("Are you a Student or Teacher?");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Teacher");
            Console.WriteLine("3. Exit");

            Console.Write("Enter Choice: ");
            initialChoice = Convert.ToInt32(Console.ReadLine());

            if (initialChoice == 1)
            {
                int studentChoice = 0;

                while (studentChoice != 4)
                {
                    Console.WriteLine("");
                    Console.WriteLine("========================================");
                    Console.WriteLine("            STUDENT REQUESTS            ");
                    Console.WriteLine("========================================");
                    Console.WriteLine("1. Request Certificate of Enrollment");
                    Console.WriteLine("2. Request Student ID");
                    Console.WriteLine("3. Request Transcript");
                    Console.WriteLine("4. Back");

                    Console.Write("Enter Choice: ");
                    studentChoice = Convert.ToInt32(Console.ReadLine());

                    if (studentChoice >= 1 && studentChoice <= 3)
                    {
                        Console.Write("Enter Student Number: ");
                        string studentNumInput = Console.ReadLine()!;

                        if (students.ContainsKey(studentNumInput))
                        {
                            Student s = students[studentNumInput];

                            StudentRequest request = new StudentRequest();

                            request.StudentNumber = s.StudentNumber;
                            request.StudentName = s.Name;

                            if (studentChoice == 1)
                            {
                                request.RequestType = "Certificate of Enrollment";
                            }
                            else if (studentChoice == 2)
                            {
                                request.RequestType = "Student ID";
                            }
                            else if (studentChoice == 3)
                            {
                                request.RequestType = "Transcript Request";
                            }

                            requestQueue.Enqueue(request);

                            Console.WriteLine("");
                            Console.WriteLine("Request added successfully!");
                            Console.WriteLine($"Student: {request.StudentName}");
                            Console.WriteLine($"Request: {request.RequestType}");

                            Console.WriteLine("");
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Student not Found!");

                            Console.WriteLine("");
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadLine();
                        }
                    }
                    else if (studentChoice == 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                }
            }
            else if (initialChoice == 2)
            {
                int teacherChoice = 0;

                while (teacherChoice != 11)
                {
                    Console.WriteLine("");
                    Console.WriteLine("========================================");
                    Console.WriteLine("        STUDENT RECORD MANAGEMENT       ");
                    Console.WriteLine("========================================");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Display All Students");
                    Console.WriteLine("3. Search Student");
                    Console.WriteLine("4. Update Student");
                    Console.WriteLine("5. Delete Student");
                    Console.WriteLine("6. View Pending Requests");
                    Console.WriteLine("7. Process Request");
                    Console.WriteLine("8. View Operation History");
                    Console.WriteLine("9. View Last Operation");
                    Console.WriteLine("10. Remove Last Operation");
                    Console.WriteLine("11. Back");

                    Console.Write("Enter Choice: ");
                    teacherChoice = Convert.ToInt32(Console.ReadLine());

                    if (teacherChoice == 1)
                    {
                        Student s = new Student();

                        Console.Write("Student's Number (Example: 2026-0001): ");
                        s.StudentNumber = Console.ReadLine()!;

                        if (students.ContainsKey(s.StudentNumber))
                        {
                            Console.WriteLine("Student Number already exists!");
                            continue;
                        }

                        Console.Write("Student's Name: ");
                        s.Name = Console.ReadLine()!;

                        Console.Write("Student's Program: ");
                        s.Program = Console.ReadLine()!;

                        Console.Write("Year Level: ");
                        s.YearLevel = Convert.ToInt32(Console.ReadLine());

                        students.Add(s.StudentNumber, s);

                        Operation operation = new Operation();
                        operation.Description = $"Added {s.Name}";
                        operationStack.Push(operation);

                        Console.WriteLine("Student added successfully!");

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (teacherChoice == 2)
                    {
                        if (students.Count == 0)
                        {
                            Console.WriteLine("No student records found!");
                        }
                        else
                        {
                            foreach (KeyValuePair<string, Student> entry in students)
                            {
                                Student s = entry.Value;

                                Console.WriteLine("");
                                Console.WriteLine($"Student Number: {s.StudentNumber}");
                                Console.WriteLine($"Student Name: {s.Name}");
                                Console.WriteLine($"Student Program: {s.Program}");
                                Console.WriteLine($"Student Year Level: {s.YearLevel}");
                            }
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (teacherChoice == 3)
                    {
                        Console.Write("Search for a student using their Student Number: ");
                        string studentNumInput = Console.ReadLine()!;

                        if (students.ContainsKey(studentNumInput))
                        {
                            Student s = students[studentNumInput];

                            Console.WriteLine("");
                            Console.WriteLine("Student Found!");
                            Console.WriteLine($"Student Number: {s.StudentNumber}");
                            Console.WriteLine($"Student Name: {s.Name}");
                            Console.WriteLine($"Student Program: {s.Program}");
                            Console.WriteLine($"Student Year Level: {s.YearLevel}");
                        }
                        else
                        {
                            Console.WriteLine("Student not Found!");
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (teacherChoice == 4)
                    {
                        Console.Write("Enter Student Number to update: ");
                        string studentNumInput = Console.ReadLine()!;

                        if (students.ContainsKey(studentNumInput))
                        {
                            Student s = students[studentNumInput];

                            Console.WriteLine("");
                            Console.WriteLine("Student Found!");
                            Console.WriteLine($"Student Number: {s.StudentNumber}");
                            Console.WriteLine($"Student Name: {s.Name}");
                            Console.WriteLine($"Student Program: {s.Program}");
                            Console.WriteLine($"Student Year Level: {s.YearLevel}");

                            Console.WriteLine("");
                            Console.WriteLine("What information do you want to update?");
                            Console.WriteLine("1. Name");
                            Console.WriteLine("2. Program");
                            Console.WriteLine("3. Year Level");

                            Console.Write("Enter choice: ");
                            int updateChoice = Convert.ToInt32(Console.ReadLine());

                            if (updateChoice == 1)
                            {
                                Console.Write("Enter new name: ");
                                s.Name = Console.ReadLine()!;

                                students[studentNumInput] = s;

                                Operation operation = new Operation();
                                operation.Description = $"Updated {s.Name}";
                                operationStack.Push(operation);

                                Console.WriteLine("Name updated successfully!");
                            }
                            else if (updateChoice == 2)
                            {
                                Console.Write("Enter new program: ");
                                s.Program = Console.ReadLine()!;

                                students[studentNumInput] = s;

                                Operation operation = new Operation();
                                operation.Description = $"Updated {s.Name}";
                                operationStack.Push(operation);

                                Console.WriteLine("Program updated successfully!");
                            }
                            else if (updateChoice == 3)
                            {
                                Console.Write("Enter new year level: ");
                                s.YearLevel = Convert.ToInt32(Console.ReadLine());

                                students[studentNumInput] = s;

                                Operation operation = new Operation();
                                operation.Description = $"Updated {s.Name}";
                                operationStack.Push(operation);

                                Console.WriteLine("Year level updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid update choice!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Student not Found!");
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (teacherChoice == 5)
                    {
                        Console.Write("Which student record do you want to delete? ");
                        string studentNumInput = Console.ReadLine()!;

                        if (students.ContainsKey(studentNumInput))
                        {
                            Student s = students[studentNumInput];

                            students.Remove(studentNumInput);

                            Operation operation = new Operation();
                            operation.Description = $"Deleted {s.Name}";
                            operationStack.Push(operation);

                            Console.WriteLine("Student deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Student not Found!");
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (teacherChoice == 6)
                    {
                        if (requestQueue.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No pending requests.");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("========================================");
                            Console.WriteLine("          PENDING STUDENT REQUESTS      ");
                            Console.WriteLine("========================================");

                            int requestNumber = 1;

                            foreach (StudentRequest request in requestQueue)
                            {
                                Console.WriteLine("");
                                Console.WriteLine($"Request #{requestNumber}");
                                Console.WriteLine($"Student Number: {request.StudentNumber}");
                                Console.WriteLine($"Student Name: {request.StudentName}");
                                Console.WriteLine($"Request Type: {request.RequestType}");

                                requestNumber++;
                            }
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (teacherChoice == 7)
                    {
                        if (requestQueue.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No pending requests to process.");
                        }
                        else
                        {
                            StudentRequest request = requestQueue.Peek();

                            Console.WriteLine("");
                            Console.WriteLine("========================================");
                            Console.WriteLine("           PROCESSING REQUEST           ");
                            Console.WriteLine("========================================");
                            Console.WriteLine($"Student Number: {request.StudentNumber}");
                            Console.WriteLine($"Student Name: {request.StudentName}");
                            Console.WriteLine($"Request Type: {request.RequestType}");

                            Console.WriteLine("");
                            Console.WriteLine("Request processed successfully!");

                            requestQueue.Dequeue();
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (teacherChoice == 8)
                    {
                        if (operationStack.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No recorded operations.");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("========================================");
                            Console.WriteLine("          OPERATION HISTORY             ");
                            Console.WriteLine("========================================");

                            int operationNumber = 1;

                            foreach (Operation operation in operationStack)
                            {
                                Console.WriteLine($"{operationNumber}. {operation.Description}");
                                operationNumber++;
                            }
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (teacherChoice == 9)
                    {
                        if (operationStack.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No recorded operations.");
                        }
                        else
                        {
                            Operation operation = operationStack.Peek();

                            Console.WriteLine("");
                            Console.WriteLine("========================================");
                            Console.WriteLine("             LAST OPERATION             ");
                            Console.WriteLine("========================================");
                            Console.WriteLine(operation.Description);
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (teacherChoice == 10)
                    {
                        if (operationStack.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No recorded operations to remove.");
                        }
                        else
                        {
                            Operation operation = operationStack.Pop();

                            Console.WriteLine("");
                            Console.WriteLine("Operation removed:");
                            Console.WriteLine(operation.Description);
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else if (teacherChoice == 11)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");

                        Console.WriteLine("");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                }
            }
            else if (initialChoice == 3)
            {
                Console.WriteLine("Goodbye!");
                return;
            }
            else
            {
                Console.WriteLine("Invalid Input!");

                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
}