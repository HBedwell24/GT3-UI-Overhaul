using System.Collections;
using UnityEngine;

    public class CarHandler : MonoBehaviour
    {
    public CarManufacturer carManufacturer;
    public CarData carData;

    public void Start()
    {
        if(string.IsNullOrEmpty(carData.id))
        {
            carData.id = System.DateTime.Now.ToLongDateString() + System.DateTime.Now.ToLongTimeString() + Random.Range(0, int.MaxValue).ToString();
            carData.carManufacturer = carManufacturer;
            SaveData.current.cars.Add(carData);
        }
    }
}