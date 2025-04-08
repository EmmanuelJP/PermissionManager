<template>
  <div>
    <b-card
      border-variant="warning"
      header="Warning"
      header-bg-variant="warning"
      header-text-variant="white"
      header-tag="header"
    >
      <template #header>
        <h6 class="mb-0">Editar solicitud permiso</h6>
      </template>
      <b-form @submit.stop.prevent="validate" @reset.prevent="onReset">
        <b-form-group
          id="input-group-1"
          label="Nombre"
          label-for="employeeFirstName"
        >
          <b-form-input
            id="employeeFirstName"
            type="text"
            name="employeeFirstName"
            v-model="model.employeeFirstName"
            placeholder="Requerido"
            v-validate="{ required: true }"
            :state="validateState('employeeFirstName')"
            aria-describedby="employeeFirstName-feedback"
            data-vv-as="Nombre"
          ></b-form-input>
          <b-form-invalid-feedback id="employeeFirstName-feedback">{{
            veeErrors.first("employeeFirstName")
          }}</b-form-invalid-feedback>
        </b-form-group>

        <b-form-group
          id="input-group-2"
          label="Apellido"
          label-for="employeeLastName"
        >
          <b-form-input
            id="employeeLastName"
            type="text"
            name="employeeLastName"
            v-model="model.employeeLastName"
            placeholder="Requerido"
            v-validate="{ required: true }"
            :state="validateState('employeeLastName')"
            aria-describedby="employeeLastName-feedback"
            data-vv-as="Apellido"
          ></b-form-input>
          <b-form-invalid-feedback id="employeeLastName-feedback">{{
            veeErrors.first("employeeLastName")
          }}</b-form-invalid-feedback>
        </b-form-group>

        <b-form-group
          id="input-group-3"
          label="Tipo permiso"
          label-for="permissionTypeId"
        >
          <b-form-select
            id="permissionTypeId"
            name="permissionTypeId"
            v-model="model.permissionTypeId"
            :options="types"
            v-validate="{ required: true }"
            :state="validateState('permissionTypeId')"
            aria-describedby="permissionTypeId-feedback"
            data-vv-as="Tipo Permiso"
          ></b-form-select>
          <b-form-invalid-feedback id="permissionTypeId-feedback">{{
            veeErrors.first("permissionTypeId")
          }}</b-form-invalid-feedback>
        </b-form-group>

        <b-form-group
          id="input-group-4"
          label="Fecha de solicitud de permiso"
          label-for="permissionDate"
        >
          <b-form-datepicker
            id="permissionDate"
            v-model="model.permissionDate"
            class="mb-2"
            name="permissionDate"
            v-validate="{ required: true }"
            :state="validateState('permissionDate')"
            aria-describedby="permissionDate-feedback"
            data-vv-as="Fecha de solicitud de permiso"
            :date-format-options="{
              year: 'numeric',
              month: 'numeric',
              day: 'numeric',
            }"
            locale="es"
          ></b-form-datepicker>
          <b-form-invalid-feedback id="permissionDate-feedback">{{
            veeErrors.first("permissionDate")
          }}</b-form-invalid-feedback>
        </b-form-group>
        <b-button @click="backToList" type="button">Cancelar</b-button>
        <b-button type="submit" class="float-right" variant="success"
          >Guardar</b-button
        >
        <b-button class="cancel-btn float-right" type="reset" variant="danger"
          >Reiniciar</b-button
        >
      </b-form>
    </b-card>
  </div>
</template>

<script lang="ts">
import SelectItem from "@/core/models/select-item.model";
import { AxiosResponse } from "axios";
import { Component, Vue } from "vue-property-decorator";

import { PermissionService, PermissionTypeService } from "@/services";
import { Permission, PermissionType } from "@/models";
@Component
export default class PermissionEdit extends Vue {
  saving = false;
  model = new Permission();
  initModel = new Permission();
  id = 0;
  permissionTypes: PermissionType[] = [];
  created() {
    this.id = Number.parseInt(this.$route.params.id);
    this.getPermissionTypes();
    this.getData();
  }
  get types() {
    let data = this.permissionTypes.map(
      (x) => new SelectItem(x.id, x.description)
    );
    data.unshift(new SelectItem(null, "Seleccione un tipo de permiso"));
    return data;
  }
  async getPermissionTypes() {
    this.permissionTypes = await PermissionTypeService.get();
  }
  onReset() {
    this.model = JSON.parse(JSON.stringify(this.initModel));
    this.$nextTick(() => this.$validator.reset());
  }
  async getData() {
    this.initModel = await PermissionService.getById(this.id);
    this.model = JSON.parse(JSON.stringify(this.initModel));
  }

  async validate() {
    const result = await this.$validator.validateAll();
    if (result) this.edit();
    this.$validator.errors.items.forEach((error) => {
      this.$bvToast.toast(error.msg, {
        title: `Error de validación`,
        variant: "danger",
        solid: true,
      });
    });
  }
  async edit() {
    try {
      this.saving = true;
      await PermissionService.update(this.id, this.model);
      this.onReset();
      this.backToList();
    } catch (errors: any) {
      const response = errors.response as AxiosResponse<any>;
      if (response && response.status === 422) {
        response.data.forEach((error: any) => {
          this.$bvToast.toast(error.errorMessage, {
            title: `Error de validación`,
            variant: "danger",
            solid: true,
          });
        });
      }
    } finally {
      this.saving = false;
    }
  }
  backToList() {
    this.$router.push(`/`);
  }
  validateState(ref: string) {
    let self = this as any;
    const dirty = self?.veeFields[ref]?.dirty;
    const validated = self?.veeFields[ref]?.validated;
    const hasContextToValidate = self.veeFields[ref] && (dirty || validated);
    return hasContextToValidate ? !self.veeErrors.has(ref) : null;
  }
}
</script>
<style>
.cancel-btn {
  margin-right: 5px;
}
</style>