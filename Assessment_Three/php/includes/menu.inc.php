<?php
$currentPage = basename($_SERVER['SCRIPT_FILENAME']);
?>
<ul>
	<li>
		<a href="index.php" <?php if ($currentPage == 'index.php') {
		echo 'id="here"';
		} ?>>Index</a>
	</li>
	<li>
		<a href="search.php" <?php if ($currentPage == 'search.php') {
		echo 'id="here"';
		} ?>>Search</a>
	</li>
	<li>
		<a href="shopping_cart.php"<?php if ($currentPage == 'shoppingcart.php') {
		echo 'id="here"';
		} ?>>Shopping Cart</a>
	</li>
</ul>
