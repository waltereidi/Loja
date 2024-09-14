
<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useDi } from '@/pinia/dependencyInjection';
import { FilterMatchMode } from '@primevue/core/api';
import UploadPicture from '@/components/Utility/Modals/UploadPicture.vue'
import UploadComposite from '@/components/Utility/Modals/UploadPicture.vue'

const di = useDi();
const request = di.getRequestController;
let dataSource = ref();
let filters = ref({
            name: { value: null, matchMode: FilterMatchMode.STARTS_WITH },
            description: { value: null, matchMode: FilterMatchMode.STARTS_WITH },

      });
      
const editingRows = ref([]);

const expandSubCategories = ref({});
const expandSubSubCategories = ref({});
request.send( 'getAsync' ,"/api/Admin/Categories/GetAllCategories")
    .then((result) => { dataSource.value = result })
    .catch((error) => console.log(error));

const onRowExpand = (event) => {

};
const onRowCollapse = (event) => {

};
const expandAll = () => {
    expandSubCategories.value = dataSource.value.reduce((acc, p) => (acc[p.id] = true) && acc, {});
};
const collapseAll = () => {
    expandSubCategories.value = null;
};
const formatCurrency = (value) => {
    return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
};
const onRowEditSave = (event) => {
    console.log(event)
};
onMounted(() => {

});

</script>

