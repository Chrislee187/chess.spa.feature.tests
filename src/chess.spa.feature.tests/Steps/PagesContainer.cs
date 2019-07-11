using chess.spa.feature.tests.Pages;

namespace chess.spa.feature.tests.Steps
{
    public static class PagesContainer
    {
        private static ChessGamePage _chessGamePage;
        public static ChessGamePage ChessGamePage => _chessGamePage ??= new ChessGamePage(Browser.Instance);

    }
}