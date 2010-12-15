<?php
include './includes/config.inc.php';
include MYSQL;

redirect_invalid_user();

include './includes/form_functions.inc.php';

include './includes/header.php';
include './includes/sidebar.php';
$items = $_SESSION['cart']->get_items();
$sum = 0;
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
			<?php foreach ($items as $value) {
			?>
				<tr>
					<td>
					<?php echo $value->title; ?>
				</td>
				<td>
					<form action="" method="post" accept-charset="utf-8">
						<input type="text" <?php echo 'name="'.$value->itemId.'" id="'.$value->itemId.'" value="'.$value->quantity.'"'?>/>
					</form>
					
					</td>
					<td>
					<?php $sum += $value->cost * $value->quantity;
						echo $value->cost; ?>
					</td>
				</tr>
			<?php
					}
			?>
					<tr>
						<td>
							<strong>Sum:</strong>
						</td>
						<td></td>
						<td>
					<?php echo $sum; ?>
				</td>
			</tr>
		</tbody>
	</table>
	<?php
				} else {
					echo 'Your shopping cart is empty';
				}
	?>
			</div>
<?php
				include './includes/footer.php';
?>