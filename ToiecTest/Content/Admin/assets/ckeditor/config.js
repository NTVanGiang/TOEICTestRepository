
/// <reference path="../ckfinder/ckfinder.html" />
/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = 'vi';
    // config.uiColor = '#AADC6E';
    config.skin = 'office2013';

    config.syntaxhighlight = 'csharp';
    config.syntaxhighlight.hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowserUrl = '/Content/Admin/assets/ckfinder/ckfinder.html';

    config.filebrowserImageBrowserUrl = '/Content/Admin/assets/ckfinder/ckfinder.html?Type = Images';
    config.filebrowserFlashBrowserUrl = '/Content/Admin/assets/ckfinder/ckfinder.html?Type = Flash';
    config.filebrowserUploadUrl = '/Content/Admin/assets/ckfinder/core/conector/aspx/conector.aspx?command=QuickUpload&type = files';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadBrowserUrl = '/Content/Admin/assets/ckfinder/core/conector/aspx/conector.aspx?command=QuickUpload&type = flash';
    CKFinder.setupCKEditor(null, '/Content/Admin/assets/ckfinder/');

    // Declare the additional plugin 
    config.extraPlugins = 'audio';

   
};
