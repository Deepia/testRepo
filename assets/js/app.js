/**
 *
 * include head HTML
 *
 */

var link = document.querySelector('link[rel="import"]');
// Clone the <template> in the import.
var template = link.import.querySelector('template');
var clone = document.importNode(template.content, true);
$('.topSection').append(clone);

/**
 *
 * initialize foundation
 *
 */
$(document).foundation();


/**
 *
 * Select all function
 *
 */
$('.dataExport').on('change', '.selectAll', function(event){
  var $selectAll = $(event.currentTarget);
  var isSelected = $selectAll.prop('checked');

  $selectAll.parents('.dataExport').find('input').prop('checked', isSelected);
});