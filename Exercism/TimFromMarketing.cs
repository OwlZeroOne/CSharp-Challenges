/*
    In this exercise you'll be writing code to print name badges for factory employees.
*/
static class Badge
{
    /*
        Employees have an ID, name and department name. Employee badge labels are formatted as follows: "[id] - name - DEPARTMENT". Implement the (static) Badge.Print() method to return an employee's badge label:

        Due to a quirk in the computer system, new employees occasionally don't yet have an ID when they start working at the factory. As badges are required, they will receive a temporary badge without the ID prefix. Modify the (static) Badge.Print() method to support new employees that don't yet have an ID:

        Even the factory's owner has to wear a badge at all times. However, an owner does not have a department. In this case, the label should print "OWNER" instead of the department name. Modify the (static) Badge.Print() method to print a label for the owner:
    */
    public static string Print(int? id, string name, string? department)
    {
        string outId;
        if (id == null) outId = "";
        else outId = $"[{id}] - ";

        return $"{outId}{name} - {(department ?? "owner").ToUpper()}";
    }
}
