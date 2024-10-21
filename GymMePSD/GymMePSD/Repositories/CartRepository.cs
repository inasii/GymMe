using GymMePSD.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls.WebParts;

namespace GymMePSD.Repositories
{
    public class CartRepository
    {
        public static DatabaseGYMEntities5 db = Singleton.instance;
        public static void AddToCart(int userId, int supplementId, int quantity)
        {
            
            MsCart existingCartItem = db.MsCarts.FirstOrDefault(c => c.UserID == userId && c.SupplementID == supplementId);

            if (existingCartItem != null)
            {
                
                existingCartItem.Quantity += quantity;
            }
            else
            {
               
                MsCart newCartItem = new MsCart
                {
                    UserID = userId,
                    SupplementID = supplementId,
                    Quantity = quantity
                };
                db.MsCarts.Add(newCartItem);
            }

           
            db.SaveChanges();
        }

        public static void ClearCart(int userId)
        {
            
            List<MsCart> cartItems = db.MsCarts.Where(c => c.UserID == userId).ToList();
            db.MsCarts.RemoveRange(cartItems);

            
            db.SaveChanges();
        }

        public static List<MsCart> GetCartItems(int userId)
        {
            
            return db.MsCarts.Where(c => c.UserID == userId).ToList();
        }
    }
}
