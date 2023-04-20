using System;

public class Worker {
    protected string name;
    private int salary;

    public Worker(string name, int salary) {
        this.name = name;
        this.salary = salary;
    }

    public override bool Equals(object obj) {
        if (obj == null || GetType() != obj.GetType()) {
            return false;
        }

        Worker w = (Worker)obj;
        return name.Equals(w.name) && salary == w.salary;
    }

    public override int GetHashCode() {
        return name.GetHashCode() ^ salary;
    }

    public override string ToString() {
        return "Name: " + name + ", Salary: " + salary;
    }

    public void DisplayMessage(string message) {
        Console.WriteLine(message);
    }

    public void IncreaseSalary(int amount) {
        salary += amount;
        DisplayMessage(name + "'s salary increased by " + amount);
    }
    
    public virtual void Dismiss()
    {
        Console.WriteLine($"{name} has been dismissed.");
    }
}

public class Manager : Worker {
    public Manager(string name, int salary) : base(name, salary) {}

    public override void Dismiss()
    {
        base.Dismiss();
        Console.WriteLine($"{name} was a Manager.");
    }
}

public class Engineer : Worker {
    public Engineer(string name, int salary) : base(name, salary) {}
    
    public override void Dismiss()
    {
        base.Dismiss();
        Console.WriteLine($"{name} was an Engineer.");
    }
}

public class Trainee : Worker {
    public Trainee(string name, int salary) : base(name, salary) {}
    public override void Dismiss()
    {
        base.Dismiss();
        Console.WriteLine($"{name} was a Trainee.");
    }
}

public class Program {
    public static void Main() {
        Manager manager = new Manager("John", 5000);
        Engineer engineer = new Engineer("Bob", 3000);
        Trainee trainee = new Trainee("Alice", 2000);

        
        Console.WriteLine();

        Console.WriteLine(manager.ToString());
        Console.WriteLine(engineer.ToString());
        Console.WriteLine(trainee.ToString());
        Console.WriteLine();

        manager.IncreaseSalary(1000);
        engineer.IncreaseSalary(500);
        trainee.IncreaseSalary(250);
        Console.WriteLine();

        manager.Dismiss();
        engineer.Dismiss();
        trainee.Dismiss();
        Console.WriteLine();

        Console.WriteLine(manager.ToString());
        Console.WriteLine(engineer.ToString());
        Console.WriteLine(trainee.ToString());
    }
}
