using System.Security.Cryptography;

namespace TH.BLL.Helpers
{
    public static class UserTagGenerator
    {
        private const string Characters =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string Generate()
        {
            var result = new char[7];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Characters[
                    RandomNumberGenerator.GetInt32(
                        Characters.Length)];
            }

            return new string(result);
        }

        //Bize rastgele 7 karakterli bir kullanıcı etiketi (UserTag) üreten bir metot sağlar. Bu metot, büyük harfler ve rakamlardan oluşan bir karakter kümesi kullanır ve her çağrıldığında benzersiz bir etiket üretir.Örnek : A1B2C34, D4E5F66, G7H8I91 gibi.
    }
}