commonModule.constant('lazyImageLoaderSrc', 'File/GetLoader');
commonModule.constant('imageBasePath', 'File/GetImage?id=');

commonModule.directive('lazyImg', ['$document', '$parse', 'lazyImageLoaderSrc','imageBasePath', function ($document, $parse, lazyImageLoaderSrc) {
          return {
              restrict: 'A',
              link: function (scope, iElement, iAttrs) {
                  var imageSrc = $parse(iAttrs.lazyImgSrc)(scope);
                  var loaderSrc = lazyImageLoaderSrc;

                  iElement[0].src = loaderSrc;

                  var img = $document[0].createElement('img');
                  img.onload = function () {
                      iElement[0].src = this.src;
                  };
                  img.onerror = function () {

                  };
                  img.src = imageSrc;
              }
          };
      }]);