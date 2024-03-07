<script lang="ts"></script>

<template>
    <DataTable v-model:editingRows="editingRows" :value="products" editMode="row" dataKey="id"
        @row-edit-save="onRowEditSave" :pt="{
        table: { style: 'min-width: 50rem' },
        column: {
            bodycell: ({ state }) => ({
                style: state['d_editing'] && 'padding-top: 0.6rem; padding-bottom: 0.6rem'
            })
        }
    }">
        <Column field="code" header="Code" style="width: 20%">
            <template #editor="{ data, field }">
                <InputText v-model="data[field]" />
            </template>
        </Column>
        <Column field="name" header="Name" style="width: 20%">

            <template #editor="{ data, field }">
                <InputText v-model="data[field]" />
            </template>
        </Column>
        <Column field="inventoryStatus" header="Status" style="width: 20%">

            <template #editor="{ data, field }">
                <Dropdown v-model="data[field]" :options="statuses" optionLabel="label" optionValue="value"
                    placeholder="Select a Status">
                    <template #option="slotProps">
                        <Tag :value="slotProps.option.value" :severity="getStatusLabel(slotProps.option.value)" />
                    </template>
                </Dropdown>
            </template>

            <template #body="slotProps">
                <Tag :value="slotProps.data.inventoryStatus"
                    :severity="getStatusLabel(slotProps.data.inventoryStatus)" />
            </template>
        </Column>
        <Column field="price" header="Price" style="width: 20%">

            <template #body="{ data, field }">
                {{ formatCurrency(data[field]) }}
            </template>

            <template #editor="{ data, field }">
                <InputNumber v-model="data[field]" mode="currency" currency="USD" locale="en-US" />
            </template>
        </Column>
        <Column :rowEditor="true" style="width: 10%; min-width: 8rem" bodyStyle="text-align:center"></Column>
    </DataTable>
</template>

<style scoped></style>