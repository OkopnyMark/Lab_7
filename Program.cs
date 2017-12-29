using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkit_lab7
{
    class Worker
    {
     
        public int ID;
        public string Surname;
        public int DepartmentID;
        public Worker(int i, string sn, int d)
        {
            this.ID = i;
            this.Surname = sn;
            this.DepartmentID = d;
        }
        public override string ToString()
        {
            return "ID: " + this.ID + "; �������: " + this.Surname +
                "; ID_������: " + this.DepartmentID;
        }
    }

    class Department
    {
        
        public int ID;
        public string name;
        public Department(int i, string n)
        {
            this.ID = i;
            this.name = n;
        }
        public override string ToString()
        {
            return "ID: " + this.ID + "; ������������ ������: " + this.name;
        }
    }

    class DepartmentWorker
    {
        public int WorkerID;
        public int DepartmentID;
        public DepartmentWorker(int iW, int iD)
        {
            this.WorkerID = iW;
            this.DepartmentID = iD;
        }
    }
     
    
    class Program
    {

        static List<Worker> worker = new List<Worker>()
        {
                new Worker(1,"��������",1),
                new Worker(2,"������������",1),
                new Worker(3,"�������",1),
                new Worker(4,"�����������",2),
                new Worker(5,"����������",2),
                new Worker(6,"�������",3),
                new Worker(7,"�������",2),
                new Worker(8,"���������",2),
                new Worker(9,"�����",1)
        };

        static List<Department> departments = new List<Department>()
        {
            new Department(1, "����� ������"),
            new Department(2, "����� �������"),
            new Department(3, "����� ������")
        };

        static List<DepartmentWorker> departmentWorkers = new List<DepartmentWorker>
        {
            new DepartmentWorker(1,1),
            new DepartmentWorker(2,1),
            new DepartmentWorker(3,1),
            new DepartmentWorker(4,2),
            new DepartmentWorker(5,2),
            new DepartmentWorker(6,3),
            new DepartmentWorker(7,2),
            new DepartmentWorker(8,2),
            new DepartmentWorker(9,1),
        };


        static void Main(string[] args)
        {
            foreach (var d in departments)
            {
                //������� (����������� ��������� �����) �� ������� ����������
                var q1 = from x in worker
                         where (d.ID == x.DepartmentID)
                         select x;
                //�������� �� ������������ ���������� ��� ������ (����� ����: ����� - ����������)
                Console.WriteLine(d);
                foreach (var x in q1) Console.WriteLine(x);
            }
            Console.WriteLine("\n");





            //���������� �� ������ ����� �������:  "�"
            string lit = "�";
            Console.WriteLine("��� ����������, � ������� ������� ���������� �� " + lit + ":");
            var q2 = from x in worker
                     where (x.Surname.Substring(0, 1) == lit)
                     select x;
            foreach (var x in q2) Console.WriteLine(x);
            if (q2.Count() == 0)
            {
                Console.WriteLine("�� � ����� ������ ��� ����������� � �������� ������������ �� ����� " + lit);
            }
            Console.WriteLine("\n");

            //������ ���� ������� � ����������� �����������(����� ������ ���������)
            Console.WriteLine("���������� ����������� � ������ �� �������:");
            foreach (var x in departments)
            {
                int num = worker.Count(y => y.DepartmentID == x.ID);
                Console.WriteLine(x + ": " + num);
            }
            Console.WriteLine("\n");

            //������ ������� � ������� ��� ���������� � �������� �� ����� �
            Console.WriteLine("������ ������� � ������� ��� ���������� � �������� �� ����� �");
            bool tr;
            foreach (var x in departments)
            {
                tr = true;
                    var q6 = from z in worker
                             where (z.DepartmentID == x.ID)
                             select z;
                    foreach (var q in q6)
                    { 
                        if ((q.Surname.Substring(0, 1) != lit)) tr=false;
                    }
                    if (tr) Console.WriteLine(x);    
            }
            Console.WriteLine("\n");


            //�������� ������ �������, � ������� ���� �� � ������ ���������� ������� ���������� � ����� ���.
            Console.WriteLine("������ �������, � ������� ���� �� � ������ ���������� ������� ���������� � ����� ���");
            foreach (var x in departments)
            {
                tr = false;
                var q7 = from c in worker
                         where (c.DepartmentID == x.ID)
                         select c;
                foreach (var x1 in q7)
                {
                    if (x1.Surname.Substring(0, 1) == lit) tr=true;
                }
                if (tr) Console.WriteLine(x);
            }
            Console.WriteLine("\n");






            //������� �� �������
            foreach (var x in departments)
            {
                //������� �� �������-�����������
                var q5 = from y in departmentWorkers
                         //��������� ������ ������ ���������� � ������� (�� �������) �������
                         where (y.DepartmentID == x.ID)
                         //����������� ��� � ������ q5
                         select y;

                //������� �� ������ �����������
                var q6 = from y in worker
                         //������� �� ������ q5
                         from z in q5
                         //��������� ������ ���������� ������ � ������� ����������
                         where (z.WorkerID == y.ID)
                         //����������� ��� � ������ �6
                         select y;
                Console.WriteLine(x);
                foreach (var y in q6) Console.WriteLine(y);
            }
            Console.WriteLine("\n");



            Console.WriteLine("������ �������, � ���������� ����������� � ���");
            foreach (var x in departments)
            {
                var q7 = from c in departmentWorkers
                         where (c.DepartmentID == x.ID)
                         select c;
                int num = worker.Count(y => y.DepartmentID == x.ID);
                Console.WriteLine(x + ": " + num);
            }
            Console.WriteLine("\n");



            
            Console.ReadKey();   
        }
    }
}