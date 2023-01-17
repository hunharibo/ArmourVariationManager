
# ArmourVariationManager

ArmourVariationManager is an open source module that allows Bannerlord modders to define armour item variations.

## Usage
* Get the release
* Unzip into Bannerlord's Modules folder
* Make sure you also have Bannerlord.Harmony mod which is a requirement
* Place this mod as last in the loading order
* Edit the armourvariations.xml in ModuleData with your desired changes
* Edit your items.xml to create variations

The module matches variationId to a naming convention in the item's StringId. In order for the code to find your matching variationId, you MUST add your items with a StringId that ends with a dot followed by the variationId.

For example:
```xml <Items>

<Item  id="aa_test_tunic"  name="{=!}AA_Test_Tunic"  mesh="casual_01"  culture="Culture.vlandia"  weight="0.6"  appearance="1"  Type="BodyArmor">

<ItemComponent>

<Armor  body_armor="4"  leg_armor="2"  arm_armor="2"  covers_body="true"  modifier_group="cloth_unarmoured"  material_type="Cloth"  />

</ItemComponent>

<Flags  UseTeamColor="true"  Civilian="true"  />

</Item>

<Item  id="aa_test_tunic.var1"  name="{=!}AA_Test_Tunic_With_Variation"  mesh="casual_01"  culture="Culture.vlandia"  weight="0.6"  appearance="1"  Type="BodyArmor">

<ItemComponent>

<Armor  body_armor="4"  leg_armor="2"  arm_armor="2"  covers_body="true"  modifier_group="cloth_unarmoured"  material_type="Cloth"  />

</ItemComponent>

<Flags  UseTeamColor="true"  Civilian="true"  />

</Item>

</Items>
``` 

Notice the ".var1" ending of the second Item's ID, where var1 is a valid variationId in the variations.xml
