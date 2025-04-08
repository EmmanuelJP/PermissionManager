<template>
  <div>
    <br>
    <jumbotron :title="title" :description="description"/>
    <router-view />
  </div>
</template>


<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class BaseVue extends Vue {
  title = 'Manejador de solicitudes de permisos';
  description = "Sistema de manejo de solicitudes de permisos"
}
</script>