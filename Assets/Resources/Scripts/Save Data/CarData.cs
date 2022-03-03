[System.Serializable]
public enum CarManufacturer
{
    Daihatsu,
    Honda,
    Mazda,
    Mitsubishi,
    Nissan,
    Subaru,
    Suzuki,
    Tommykaira,
    Toyota,
    Tickford,
    Gillet,
    Citroen,
    Peugeot,
    Renault,
    Audi,
    BMW,
    MercedesBenz,
    Opel,
    RUF,
    Volkswagen,
    AlfaRomeo,
    Fiat,
    Lamborghini,
    Lancia,
    Pagani,
    AstonMartin,
    Jaguar,
    Lister,
    Lotus,
    Mini,
    TVR,
    Acura,
    Chevrolet,
    Chrysler,
    Dodge,
    Ford,
    Panoz,
    Shelby
}

[System.Serializable]
public enum Country
{
    Japan,
    Australia,
    Belgium,
    France,
    Germany,
    Italy,
    UnitedKingdom,
    USA
}

[System.Serializable]
public class CarData
{
    public string id;
    public Country country;
    public CarManufacturer carManufacturer;
    public string carName;
    public int carValue;
    public string drivetrain;
    public int ppCount;
    public string dataAcquired;
}