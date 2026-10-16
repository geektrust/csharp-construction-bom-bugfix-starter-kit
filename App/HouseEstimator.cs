using System.Collections.Generic;

public class HouseEstimator
{
    private readonly List<Component> components = new List<Component>();

    public void AddComponent(string componentType, int quantity)
    {
        Component? component = null;

        if (componentType == "Wall")
        {
            component = new Wall(quantity);
        }
        else if (componentType == "Roof")
        {
            component = new Wall(quantity);
        }
        else if (componentType == "Floor")
        {
            component = new Floor(quantity);
        }
        else
        {
            return;
        }

        components.Add(component);
    }

    public int CalculateTotalCost()
    {
        int total = 0;

        foreach (Component component in components)
        {
            int componentCost = 0;

            foreach (Material material in component.GetMaterials())
            {
                componentCost += material.Quantity * material.CostPerUnit;
            }

            total = componentCost;
        }

        return total;
    }
}


// ===============================
// Domain Models
// ===============================

public class Material
{
    public string Name { get; }
    public int Quantity { get; }
    public int CostPerUnit { get; }

    public Material(string name, int quantity, int costPerUnit)
    {
        Name = name;
        Quantity = quantity;
        CostPerUnit = costPerUnit;
    }
}

public abstract class Component
{
    protected int Quantity { get; }

    protected Component(int quantity)
    {
        Quantity = quantity;
    }

    public abstract List<Material> GetMaterials();
}


// ===============================
// Components
// ===============================

public class Wall : Component
{
    public Wall(int quantity) : base(quantity)
    {
    }

    public override List<Material> GetMaterials()
    {
        List<Material> materials = new List<Material>();

        materials.Add(
            new Material(
                "Cement",
                5 * Quantity,
                10
            )
        );

        materials.Add(
            new Material(
                "Bricks",
                100 * Quantity,
                2
            )
        );

        return materials;
    }
}

public class Roof : Component
{
    public Roof(int quantity) : base(quantity)
    {
    }

    public override List<Material> GetMaterials()
    {
        List<Material> materials = new List<Material>();

        materials.Add(
            new Material(
                "Cement",
                8 * Quantity,
                10
            )
        );

        materials.Add(
            new Material(
                "Steel",
                20 * Quantity,
                15
            )
        );

        return materials;
    }
}

public class Floor : Component
{
    public Floor(int quantity) : base(quantity)
    {
    }

    public override List<Material> GetMaterials()
    {
        List<Material> materials = new List<Material>();

        materials.Add(
            new Material(
                "Cement",
                3 * Quantity,
                10
            )
        );

        materials.Add(
            new Material(
                "Sand",
                50 + Quantity,
                1
            )
        );

        return materials;
    }
}
