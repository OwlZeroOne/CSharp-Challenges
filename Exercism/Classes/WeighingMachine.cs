class WeighingMachine
{
    private double weight;
    private double tareAdjustment;
    private string displayWeight = "";

    public WeighingMachine(int precision)
    {
        Precision = precision;
        tareAdjustment = 5;
    }

    private void UpdateDisplayWeight()
    {
        displayWeight = $"{(weight - tareAdjustment).ToString($"N{Precision}")} kg";
    }

    public int Precision { get; }

    public double Weight
    {
        get => weight;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            weight = value;
            UpdateDisplayWeight();
        }
    }

    public double TareAdjustment
    {
        get => tareAdjustment;
        set
        {
            tareAdjustment = value;
            UpdateDisplayWeight();
        }
    }
    public string DisplayWeight => displayWeight;
}