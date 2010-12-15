<?php
include './includes/config.inc.php';
include MYSQL;

redirect_invalid_user();

include './includes/form_functions.inc.php';

include './includes/header.php';
include './includes/sidebar.php';
$items = $_SESSION['cart']->get_items();
?>
<div id="content" class="column-right">
	<h1>
		Shopping Cart
	</h1>
	<?php
	if (isset($items)) {
	?>
	<table>
		<thead>
		<th>
			Item
		</th>
		<th>
			Quantity
		</th>
		<th>
			Price
		</th>
		</thead>
		<tbody>
			<?php
			foreach ($items as $value){

			}
			?>
		</tbody>
	</table>
	<?php
	}
	else
	{
		echo 'Your shopping cart is empty';
	}
	?>
</div>
<?php
include './includes/footer.php';
?>