namespace FCG.Domain.Library;

public class LibraryResponse(IEnumerable<LibraryItemResponse> LibraryItems, int TotalCount);