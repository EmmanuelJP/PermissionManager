<template>
  <div>
    <b-modal
      :visible="show"
      @cancel="cancel"
      @ok="ok"
      :title="title"
      ok-variant="danger"
    >
      <p class="my-4">{{ description }}</p>
    </b-modal>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class Confirmation extends Vue {
  @Prop({ default: "Confirmación la operación" }) private title!: string;
  @Prop({ default: "¿Esta seguro que desea eliminar el registro?" })
  @Prop() public show!: boolean;
  @Prop() public entityId!: number;
  private description!: string;
  cancel() {
    this.$emit("update:show", false);
    this.$emit("update:entityId", null);
    this.$emit("cancel");
  }

  ok() {
    this.$emit("update:show", false);
    this.$emit("ok", this.entityId);
  }
}
</script>

