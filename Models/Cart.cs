namespace TheWaterProject.Models;

public class Cart
{
    public List<CartLine> Lines { get; set; } = new List<CartLine>();

    public void AddItem(Project proj, int quantity)
    {
        CartLine? line = Lines
            .Where(x => x.Project.ProjectId == proj.ProjectId)
            .FirstOrDefault();

        // already been added too cart??
        if (line == null)
        {
            Lines.Add(new CartLine
            {
                Project = proj,
                Quantity = quantity
            });
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public void RemoveLine(Project proj) => Lines.RemoveAll(x => x.Project.ProjectId == proj.ProjectId);

    public void Clear() => Lines.Clear();

    public decimal CalculateTotal() =>
        Lines.Sum(x => 25 * x.Quantity); // we use a lambda function here because it is easier to put in 1 line
    // lambda functions will return what we put into the function automatically without the need for a return statement.

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Project Project { get; set; } = new();
        public int Quantity { get; set; }
    }
}