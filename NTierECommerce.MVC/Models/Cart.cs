namespace NTierECommerce.MVC.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> _myCart = new Dictionary<int, CartItem>();

        public void AddItem(CartItem cartItem)
        {
            if(_myCart.ContainsKey(cartItem.Id))
            {
                _myCart[cartItem.Id].Quantity++;
                return;
            }
            _myCart.Add(cartItem.Id, cartItem);
        }

        public void UpdateItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.Id))
            {
                _myCart[cartItem.Id].Quantity = cartItem.Quantity;
                return;
            }
            _myCart.Add(cartItem.Id, cartItem);
        }
        public void DeleteItem(CartItem cartItem)
        {
            if(_myCart.ContainsKey(cartItem.Id))
            {
                _myCart.Remove(cartItem.Id);
                return;
            }
        }
    }
}
