namespace ПЗ1_09._03_
{
    public class Student
    {
        public string Surname { get; set; }
        public int Grade { get; set; }

        public override string ToString()
        {
            return $"{Surname} ({Grade})";
        }
    }
}