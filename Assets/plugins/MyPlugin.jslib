 mergeInto(LibraryManager.library, {
    IsMobile: function()
    {
        return UnityLoader.SystemInfo.mobile;
    },
    OpenWebsite: function (url) {
        window.open(Pointer_stringify(url).toString());
    }
});