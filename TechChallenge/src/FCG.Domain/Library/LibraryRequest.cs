namespace FCG.Domain.Library;

public class LibraryRequest(int UserId, IEnumerable<LibraryItemRequest> LibraryItems, bool Wishlist = false);