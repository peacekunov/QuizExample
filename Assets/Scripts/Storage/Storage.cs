using System.Threading.Tasks;

public interface Storage<T>
{
    bool HasData();

    void SaveData(T data);

    Task<T> LoadData();
}