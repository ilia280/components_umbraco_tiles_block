angular.module("umbraco").controller("TilesBlock.Controller", function ($scope) {

	$scope.sortMode = false;

	function Item() {
		this.contentId = null;
		this.type = '';
		this.title = '';
		this.description = '';
	}

	$scope.control.value = [];

	$scope.addItem = function () {
		$scope.control.value.push(new Item());
		_.defer(function () { $scope.$apply(); });
	}

	$scope.removeItem = function (item) {
		$scope.control.value.splice($scope.control.value.indexOf(item), 1);
		_.defer(function () { $scope.$apply(); });
	}

	$scope.availableItems = [
		{
			alias: 'customTile',
			name: 'Custom tile',
			icon: 'icon-post-it'
		},
		{
			alias: 'newsTile',
			name: 'News tile',
			icon: 'icon-newspaper-alt'
		}
	];

	$scope.openOverlay = function (event) {
		$scope.overlay = {
			view: "itempicker",
			title: "Choose type of tile",
			show: true,
			filter: false,
			event: event,
			availableItems: $scope.availableItems,
			submit: function (model) {
				console.log(model.selectedItem.alias);

			//$scope.addControl(model.selectedItem, area, index);
				$scope.overlay.show = false;
				$scope.overlay = null;
			},
			close: function (oldModel) {
				$scope.overlay.show = false;
				$scope.overlay = null;
			}
		};
	};

	
});
