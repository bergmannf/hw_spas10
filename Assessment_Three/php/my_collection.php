<?php
/**
 *
 */
interface MyCollection {
	function add_item($article_number, $quantity);
	function remove_item($article_number, $quantity);
	function show();
}
?>