<template>
  <div class="jumbotron jumbotron-fluid">
  <div class="container">
    <h1 class="display-4">{{title}}</h1>
    <p class="lead">{{description}}</p>
  </div>
</div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class Jumbotron extends Vue {
  @Prop() private title!: string;
  @Prop() private description!: string;
}
</script>

