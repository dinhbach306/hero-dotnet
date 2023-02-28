using System.Text.Json.Serialization;

namespace Hero_net.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
//Dùng để serialize enum sang tên khi qua postman, swagger mà không hiện số 1, 2, 3
public enum RpgClass
{
    //Bắt đầu theo thứ tự
    Knight = 1,
    Mage = 2,
    Cleric = 3
}